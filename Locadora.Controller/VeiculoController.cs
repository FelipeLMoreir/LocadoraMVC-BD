using Locadora.Controller.Interfaces;
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
    public class VeiculoController : IVeiculoController
    {
        public void AdicionarVeiculo(Veiculos veiculo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Veiculos.INSERTVEICULO, connection, transaction);

                    command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                    command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                    command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                    command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                    command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiculo);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void AtualizarStatusVeiculo(string statusVeiculo, string placa)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            Veiculos veiculo = BuscarVeiculoPlaca(placa) ?? throw new Exception("Veículo não encontrado");

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                SqlCommand command = new SqlCommand(Veiculos.UPDATESTATUSVEICULO, connection, transaction);
                try
                {
                    command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                    command.Parameters.AddWithValue("@VeiculoID", veiculo.VeiculoID);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar status do veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar status do veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public Veiculos BuscarVeiculoPlaca(string placa)
        {
            var categoriaController = new CategoriaController();
            Veiculos veiculo = null;
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlCommand command = new SqlCommand(Veiculos.SELECTVEICULOBYPLACA, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Placa", placa);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veiculo = new Veiculos(
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetInt32(5),
                                reader.GetString(6)
                            );
                            veiculo.setVeiculoID(reader.GetInt32(0));

                            veiculo.setNomeCategoria(categoriaController.BuscarCategoriaPorId
                                (veiculo.CategoriaID).Nome);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    
                    throw new Exception("Erro ao listar veículos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao encontrar veículos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return veiculo ?? throw new Exception("Veículo não encontrado");
            }
        }
        public void DeletarVeiculo(int idVeiculo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                SqlCommand command = new SqlCommand(Veiculos.DELETEVEICULO, connection, transaction);
                try
                {
                    command.Parameters.AddWithValue("@VeiculoID", idVeiculo);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Veiculos> ListarTodosVeiculos()
        {
            List<Veiculos> veiculos = new List<Veiculos>();
            var categoriaController = new CategoriaController();
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlCommand command = new SqlCommand(Veiculos.SELECTALLVEICULOS, connection))
            {
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var veiculo = new Veiculos(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetString(5)
                            );
                            veiculo.setNomeCategoria(categoriaController.BuscarCategoriaPorId
                                (veiculo.CategoriaID).Nome);
                            veiculos.Add(veiculo);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar veículos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao listar veículos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return veiculos;
            }
        }
    }
}
