using MiCore.DTO;
using MiDAL.Models;
using MiDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiDAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public proyectoContext _context { get; set; }
        public UsuarioRepository(proyectoContext context)
        {
            _context = context;
        }
        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Usuarios.Any(u => u.Nick == usuarioDTO.username && u.Passwd == usuarioDTO.password && usuarioDTO.username== usuarioDTO.password);
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var miUser = new Usuarios();
            //miUser.IdUser = usuarioDTO.IdUser;
            miUser.Nick = usuarioDTO.username;
            miUser.Passwd = usuarioDTO.password;
            miUser.Rango = usuarioDTO.Rango;
            miUser.Dni = usuarioDTO.Dni;
            miUser.FechaAlta = usuarioDTO.FechaAlta;
            _context.Usuarios.Add(miUser);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Usuarios.ToList();

            //Mapeo de Usuario a UsuarioDTO
            List<UsuarioDTO> usuariosdto = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    username = u.Nick,
                    password = u.Passwd,
                    Dni = u.Dni,
                    Rango = u.Rango,
                    FechaAlta = u.FechaAlta,
                };
                usuariosdto.Add(usuario);
            }

            return usuariosdto;

        }
    }
}
