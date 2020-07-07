//References
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
public class SQLite : MonoBehaviour
{
    public static IDataReader dr;
    string filepath;
    string sqlQuery;
    string connectionString;
    public IDbConnection dbConnection;
    public IDbCommand dbCmd;

    public Usuario usuario;

    public void Start()
    {
        
        if (Application.platform != RuntimePlatform.Android) {
         
            filepath = Application.dataPath + "/StreamingAssets/" + "BiosysDB.s3db";
            
         } else {
        filepath = Application.persistentDataPath + "/" + "BiosysDB.s3db";
        
        if (!File.Exists(filepath) || new System.IO.FileInfo(filepath).Length == 0)
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/StreamingAssets/BiosysDB");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BiosysDB.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }
    }

        connectionString = "URI=file:" + filepath;

    }
    public void Desconectar()
    {
        dbConnection.Close();
    }

    public int Inserir(TMPro.TMP_InputField txtnome, TMPro.TMP_InputField txtsenha)
    {
        int id_usuario = 0;
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            string nome = txtnome.text;
            string senha = txtsenha.text;
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("INSERT INTO usuario(nick, senha) VALUES(\"{0}\",\"{1}\") ", nome, senha);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            id_usuario = Login(txtnome.text, txtsenha.text);
            usuario.setId(id_usuario);
            dataSet(usuario.getId());
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            
        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
        
        return id_usuario;
        
    }
    public int Login(string nome, string senha)
    {
        int id_usuario = 0;
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT id FROM usuario WHERE nick = \"{0}\" AND senha = \"{1}\" AND exc = 'n' ", nome,senha);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                Debug.Log("As informações conferem");
                Debug.Log(dr.GetInt32(0));
            }
                id_usuario = dr.GetInt32(0);
                usuario.setId(id_usuario);
                dataSet(usuario.getId());
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dr.Close();
            dbConnection.Close();
            dbConnection.Dispose();
        }
        return id_usuario;
    }
    
    public void dataSet(int id_usuario)
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT nome, senha, pontos, exc FROM usuario WHERE id = \"{0}\" ", id_usuario);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                Debug.Log("OK. Conectando informações.");
                Debug.Log(dr.GetInt32(0));
                string nome = dr.GetString(0);
                string senha = dr.GetString(1);
                int pontuacao = dr.GetInt32(2);
                char exc = dr.GetChar(3);

               usuario.setId(id_usuario);
               usuario.setNick(nome);
               usuario.setPontos(pontuacao);
               usuario.setSenha(senha);
               usuario.setExc(exc);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }
    }
    public string MostrarPerfil(int id_usu, int dado)
    {
        string dado_return = "";
        string nome = "";
        string senha = "";
        int pontuacao = 0;
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT nick, senha, pontos FROM usuario WHERE id = \"{0}\" AND exc = 'n'", id_usu);

            dbCmd.CommandText = sqlQuery;
            dr = dbCmd.ExecuteReader();
            while(dr.Read())
            {
               Debug.Log("Entrou");
               nome = dr.GetString(0);
               senha = dr.GetString(1);
               pontuacao = dr.GetInt32(2);

               usuario.setId(id_usu);
               usuario.setNick(nome);
               usuario.setPontos(pontuacao);
               usuario.setSenha(senha);
               usuario.setExc('n');
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }

        switch(dado)
        {
            case 0:
                dado_return = nome;
                break;
            case 1:
                dado_return = senha;
                break;
            case 2:
                dado_return = pontuacao.ToString();
                break;
        }
        return dado_return;
    }

    public void Delete(int id_usu) //Exclusão LÓGICA
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();

            sqlQuery = String.Format("UPDATE usuario SET exc = 's' WHERE id = \"{0}\" ", id_usu);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            usuario.setExc('s');
        }
        catch (Exception e){Debug.Log(e.Message);}
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }

    public void AlterarUsuario(int id_usu, string nome, string senha)
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("UPDATE usuario SET nick = \"{1}\", senha = \"{2}\" WHERE id = \"{0}\" AND exc = 'n' ", id_usu, nome, senha);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            usuario.setId(id_usu);
            dataSet(usuario.getId());
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }

    public bool UsuarioExiste(string nome)
    {
        bool existe = false;
        try
        {

            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT * FROM usuario WHERE nick = \"{0}\" AND exc = 'n' ", nome);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                existe = true;
                Debug.Log("As informações conferem");
            }                
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dr.Close();
            dbConnection.Close();
            dbConnection.Dispose();
            
        }
        return existe;
    }

    public void GanharPontos(int media, int id_usu)
    {
       int pontos = 0;
       try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT pontos FROM usuario WHERE id = \"{0}\" AND exc = 'n' ", id_usu);

            dbCmd.CommandText = sqlQuery;
            dr = dbCmd.ExecuteReader();

            if(dr.Read())
            {
                pontos = dr.GetInt32(0);
            }

            pontos +=media;

            sqlQuery = String.Format("UPDATE usuario SET pontos = \"{0}\" WHERE id = \"{1}\" AND exc = 'n' ", pontos, id_usu);
            
            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            usuario.setPontos(pontos);

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }          

    }

    public void Comprar(int valor, int id_usu)
    {
        int pontos = usuario.getPontos();
        int attPontos = pontos - valor;
        if(pontos < valor)
        {
            Debug.Log("Pontos insuficientes");
            return;
        }

        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
           
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("UPDATE usuario SET pontos = \"{0}\" WHERE id = \"{1}\" AND exc = 'n' ", attPontos, id_usu);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();

            usuario.setPontos(attPontos);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }

    }

    public void LancarAcertos(int idTema, int idUsuario, int acertos, bool simulado)
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            if(!simulado)
                sqlQuery = String.Format("INSERT INTO usuario_temas(id_usuario, id_tema, acertos) VALUES(\"{0}\",\"{1}\",\"{2}\", 'n') ", idUsuario, idTema, acertos);
            else
                sqlQuery = String.Format("INSERT INTO usuario_temas(id_usuario, id_tema, acertos, simulado) VALUES(\"{0}\",\"{1}\",\"{2}\", 's') ", idUsuario, idTema, acertos);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            
        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
        
    }

    public int AcertosPorQuestao(int id_usuario, int id_tema)
    {
        int acertos = 0;
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT MAX(acertos) FROM usuario_tema WHERE id_usuario = \"{0}\" AND id_tema = \"{1}\" and simulado = 'n' ", id_usuario, id_tema);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                acertos = dr.GetInt32(0);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }
        return acertos;
    }

    public void UsuarioJogo(int idJogo, int idUsuario)
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();

            sqlQuery = String.Format("INSERT INTO usuario_jogo(id_usuario, id_jogo) VALUES(\"{0}\",\"{1}\") ", idUsuario, idJogo);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            
        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }

    }

    public void UsuarioAnimal(int idUsuario, int idAnimal)
    {
         try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();

            sqlQuery = String.Format("INSERT INTO usuario_animal(id_usuario, id_animal) VALUES(\"{0}\",\"{1}\") ", idUsuario, idAnimal);

            dbCmd.CommandText = sqlQuery;
            dbCmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            
        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }
    public int VezesJogado(int idUsuario, int idJogo)
    {
        int jogados = 0;
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Stablishing connection to: " + connectionString);
            dbCmd = dbConnection.CreateCommand();
            sqlQuery = String.Format("SELECT COUNT(id) FROM usuario_jogo WHERE id_usuario = \"{0}\" AND id_jogo = \"{1}\" ", idUsuario, idJogo);

            dbCmd.CommandText = sqlQuery;
            
            dr = dbCmd.ExecuteReader();
            if(dr.Read())
            {
                jogados = dr.GetInt32(0);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

        }
        finally
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dr.Close();
        }
        return jogados;
    }

}