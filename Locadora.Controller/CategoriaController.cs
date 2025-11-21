using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Categoria.INSERTCATEGORIA, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", categoria.Nome);
                    command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                    command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                    var categoriaId = Convert.ToInt32(command.ExecuteScalar());

                    categoria.setCategoriaId(categoriaId);

                    var documentoController = new DocumentoController();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categoria: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Categoria> ListarTodasCategorias()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Categoria.SELECTALLCATEGORIAS, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Categoria> categorias = new List<Categoria>();
                while (reader.Read())
                {
                    Categoria categoria = new Categoria(
                        reader["Nome"].ToString()!,
                        reader["Descricao"].ToString()!,
                        Convert.ToDecimal(reader["Diaria"])
                    );
                    categoria.setCategoriaId(Convert.ToInt32(reader["CategoriaID"]));
                    categorias.Add(categoria);
                }
                reader.Close();
                return categorias;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar categorias: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar categorias: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public Categoria BuscarCategoriaPorNome(string nome)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Categoria.SELECTCATEGORIAPORNOME, connection);
                command.Parameters.AddWithValue("@Nome", nome);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var categoria = new Categoria(
                        reader["Nome"].ToString()!,
                        reader["Descricao"].ToString()!,
                        Convert.ToDecimal(reader["Diaria"])
                    );
                    categoria.setCategoriaId(Convert.ToInt32(reader["CategoriaID"]));
                    return categoria;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar categoria por nome: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar categoria por nome: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void AtualizarCategoria(Categoria categoria, string descricao, decimal diaria)
        {
            var categoriaExistente = BuscarCategoriaPorNome(categoria.Nome);
            if (categoriaExistente == null)
            {
                throw new Exception("Categoria não encontrada para atualização.");
            }
            categoriaExistente.setDescricao(descricao);
            categoriaExistente.setDiaria(diaria);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Categoria.UPDATECATEGORIA, connection);
                command.Parameters.AddWithValue("@Descricao", categoriaExistente.Descricao);
                command.Parameters.AddWithValue("@Diaria", categoriaExistente.Diaria);
                command.Parameters.AddWithValue("@CategoriaID", categoriaExistente.CategoriaId);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao atualizar categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar categoria: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeletarCategoria(string nome)
        {
            var categoriaExistente = BuscarCategoriaPorNome(nome);
            if (categoriaExistente == null)
            {
                throw new Exception("Categoria não encontrada para deleção.");
            }

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Categoria.DELETECATEGORIA, connection);
                command.Parameters.AddWithValue("@CategoriaID", categoriaExistente.CategoriaId);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao deletar categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar categoria: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
