using MiCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBL.Contracts
{

    public interface IUsuarioBL
    {
        bool Login(UsuarioDTO usuarioDTO);
        void Add(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
    }
}
