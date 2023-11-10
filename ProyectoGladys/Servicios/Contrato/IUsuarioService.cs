using Microsoft.EntityFrameworkCore;
using ProyectoGladys.Models;


namespace ProyectoGladys.Servicios.Contrato
{
	public interface IUsuarioService
	{
		Task<Usuario> GetUsuario(string correo, string clave);
		Task<Usuario> SaveUsuario(Usuario modelo);
	}
}
