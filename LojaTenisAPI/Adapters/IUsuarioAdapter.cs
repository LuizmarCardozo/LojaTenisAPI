using LojaTenisAPI.Model;
using LojaTenisAPI.ViewModels;

namespace LojaTenisAPI.Adapters
{
    public static class IUsuarioAdapter
    {
        public static Usuario ToDomain(this UsuarioVMRequest usuarioVM)
        {
            //Tratamento para não dar erro se enviar null na viewmodel
            // == null ou is null mesma coisa vou colocar abaixo para vc ver
            if (usuarioVM == null) return null;

            //Senha não é tratada nessa camada por não ser responsabilidade da mesma
            return new Usuario
            {
                Email = usuarioVM.Email,
                Nome = usuarioVM.Nome,
            };
        }

        /// <summary>
        /// Usuario response é diferente do request pois ele não pode enviar a senha 
        /// de volta para o foronte por segurança!
        /// Alguns casos vc só vai ter o VM que vai ser tanto o request como o response
        /// </summary>
        /// <param name="usuario">Domínio usuário</param>
        /// <returns>UsuarioVMReponse</returns>
        public static UsuarioVMReponse ToViewModel(this Usuario usuario)
        {
            //outra forma de tratar null
            if (usuario is null) return null;

            //
            return new UsuarioVMReponse
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
        }
    }
}
