using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{   
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //TipoDeRetorno       NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        ///    Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">esse parametro é o objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retorna todos os genero cadastrados, que estão dentro de uma lista de objeto(GeneroDomain)
        /// </summary>
        /// <returns> Retorna uma lista de objeto(genero) </returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Buscar um objeto através do seu id
        /// </summary>
        /// <param name="Id">Id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int Id);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="attGenero">Objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain corpoGenero);



        /// <summary>
        /// Atualizar gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="urlGenero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain urlGenero);


        /// <summary>
        /// Deletar um objeto(genero) existente
        /// </summary>
        /// <param name="Id">Id do objeto a ser deletado</param>
        void Deletar(int Id);
    }
}
