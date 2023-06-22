using System.Data.SqlClient;

namespace AtendimentosRandomicos.Connection;

public class ConnectionDB
{
    public static void InsertToSqlDb(string senhaAtendimento, int idAtendimento, int idHospital, int idEspecialidade, int idTriagem, int idAssociado, int tempoAtendimento)
    {
        Console.WriteLine("A inserção de dados será iniciada em 5 segundos, pressione CRTL + C para interromper.");
        Thread.Sleep(1000);
        Console.Write("5...");
        Thread.Sleep(1000);
        Console.Write("4...");
        Thread.Sleep(1000);
        Console.Write("3...");
        Thread.Sleep(1000);
        Console.Write("2...");
        Thread.Sleep(1000);
        Console.WriteLine("1");
        Thread.Sleep(100);

        SqlConnection conn = new SqlConnection();
        string strConnLocal = "Data Source=localhost; Initial Catalog=DB-TCC-QUANTODEMORA; User Id=sa; Password=123456";
        string strConnSomee = "workstation id=DB-TCC-QUANTODEMORA.mssql.somee.com;packet size=4096;user id=quantodemoraadm_SQLLogin_1;pwd=mnczwhoccv;data source=DB-TCC-QUANTODEMORA.mssql.somee.com;persist security info=False;initial catalog=DB-TCC-QUANTODEMORA;Encrypt=False;trustservercertificate=false";
        
        try
        {
            using (conn = new SqlConnection(strConnSomee))
            {
                string query = "INSERT INTO Atendimentos" +
                    "(senhaAtendimento, idAtendimento, idHospital, idEspecialidade, idTriagem, idAssociado, tempoAtendimento)" +
                    "VALUES (@senhaAtendimento, @idAtendimento, @idHospital, @idEspecialidade, @idTriagem, @idAssociado, @tempoAtendimento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@senhaAtendimento", senhaAtendimento);
                    cmd.Parameters.AddWithValue("@idAtendimento", idAtendimento);
                    cmd.Parameters.AddWithValue("@idHospital", idHospital);
                    cmd.Parameters.AddWithValue("@idEspecialidade", idEspecialidade);
                    cmd.Parameters.AddWithValue("@idTriagem", idTriagem);
                    cmd.Parameters.AddWithValue("@idAssociado", idAssociado);
                    cmd.Parameters.AddWithValue("@tempoAtendimento", tempoAtendimento);

                    conn.Open();
                    Console.WriteLine("Open connection!");
                    int result = cmd.ExecuteNonQuery();

                    if (result != 1)
                        throw new Exception("Error inserting data into Database!");

                    Console.WriteLine("Success inserting data into Database!");
                    Console.WriteLine($"Senha: {senhaAtendimento} - Id do Atendimento: {idAtendimento} - Id do Hospital: {idHospital} - Id da Especialidade {idEspecialidade} - Id da Triagem {idTriagem} - Id do Associado {idAssociado} - Tempo do Atendimento: {tempoAtendimento} min");
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            conn.Close();
            Console.WriteLine("Close connection!");
            Thread.Sleep(9900);
        }
    }
}

//https://stackoverflow.com/questions/19956533/sql-insert-query-using-c-sharp