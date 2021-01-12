using MiBL.Contracts;
using MiCore.DTO;
using MiDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool Login(UsuarioDTO usuarioDTO)
        {
           return _usuarioRepository.Login(usuarioDTO);
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Add(usuarioDTO);
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _usuarioRepository.Get();
            return usuarios;
        }
    }
}
