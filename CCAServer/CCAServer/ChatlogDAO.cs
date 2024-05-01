using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCAServer
{
    internal class ChatlogDAO
    {
        private NpgsqlConnection conn = null;
        public ChatlogDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }
        // DBからデータを受け取りlistでデータを返す
        public List<ChatlogDTO> chatlog_get()
        {
            if (conn == null) return null;
            var list = new List<ChatlogDTO>();
            // 実行SQL
            string sql = @"SELECT * FROM chatlog";

            try
            {
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                DateTime now = DateTime.Now;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChatlogDTO()
                            {
                                Id = (int)reader["id"],
                                UserName = (string)reader["username"],
                                Message = (string)reader["message"],
                            });

                            Debug.WriteLine($"{list}");
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"データなし");
                    }
                    reader.Close();
                }
                conn.Close();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(ne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
            return list;
        }
        // データグリッドビューに表示させる情報を受け渡す
        public NpgsqlDataAdapter select_all_data()
        {

            if (conn == null) return null;
            NpgsqlDataAdapter dataAdapter = null;

            string sql = @"SELECT * FROM chatlog order by id desc";
            try
            {
                dataAdapter = new NpgsqlDataAdapter(sql, conn);
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(ne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
            return dataAdapter;
        }

        // サーバーに送られてきたメッセージ名前:メッセージの形で別けてインサートする
        public void insert_message(string username, string message)
        {
            if (conn == null) return;
            // chatlogテーブルにTextBox内に表示されたログを保存する
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO chatlog (username, message, timestamp) VALUES (@username, @message, NOW())"; ;
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("message", message);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(ne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }
        // クライアントから送られてきた文字列にHITしたデータをlistで返す
        public List<ChatlogDTO> SearchData(string searchText)
        {
            if (conn == null) return null;
            var searchResults = new List<ChatlogDTO>();
            string sql = @"SELECT * FROM chatlog WHERE username LIKE @searchText OR message LIKE @searchText  order by id desc LIMIT 100";

            try
            {
                conn.Open();

                using (var command = new NpgsqlCommand(sql, conn))
                {
                    // パラメータを設定
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Add(new ChatlogDTO()
                            {
                                Id = (int)reader["id"],
                                UserName = (string)reader["username"],
                                Message = (string)reader["message"],
                                Time = (DateTime)reader["timestamp"]
                            });
                        }
                    }
                }
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(ne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
            return searchResults;
        }

        // クライアントから送られてきた時間帯にHITしたデータをlistで返す
        public List<ChatlogDTO> SearchByTime(DateTime startTime, DateTime endTime)
        {
            List<ChatlogDTO> result = new List<ChatlogDTO>();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM chatlog WHERE timestamp BETWEEN @startTime AND @endTime  order by id desc LIMIT 100";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@endTime", endTime);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ChatlogDTO()
                            {
                                Id = (int)reader["id"],
                                UserName = (string)reader["username"],
                                Message = (string)reader["message"],
                                Time = (DateTime)reader["timestamp"]
                            });
                        }
                    }
                }
            }
            catch (NpgsqlException ne)
            {
                Debug.WriteLine(ne.Message);
                Debug.WriteLine(ne.StackTrace);
                throw new Exception("検索エラー");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                throw new Exception("検索処理エラー");
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
