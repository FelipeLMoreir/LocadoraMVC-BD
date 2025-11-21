using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Categoria.INSERTCATEGORIA, connection);

                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao adicionar categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar categoria: " + ex.Message);
            }
            finally
            {
                connection.Close();
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
        public Categoria BuscarCategoriaPorId(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Categoria.SELECTCATEGORIAPORID, connection);
                command.Parameters.AddWithValue("@CategoriaID", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var categoria = new Categoria(
                        reader["Nome"].ToString()!,
                        reader["Descricao"].ToString()!,
                        Convert.ToDecimal(reader["Diaria"])
                    );
                    //categoria.setCategoriaId(Convert.ToInt32(reader["CategoriaID"]));
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
            var categoriaExistente = BuscarCategoriaPorId(categoria.CategoriaId);
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
        public void DeletarCategoria(int id)
        {
            var categoriaExistente = BuscarCategoriaPorId(id);
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

