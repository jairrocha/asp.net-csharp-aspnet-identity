using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid) 
            {
                var dbContext = new IdentityDbContext<UsuarioAplicacao>("DefaultConnection");
                var userStore = new UserStore<UsuarioAplicacao>(dbContext);
                var userManager = new UserManager<UsuarioAplicacao>(userStore);

                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                userManager.CreateAsync(novoUsuario, modelo.Senha);

                return RedirectToAction("Index", "Home"); //Podemos incluir o usuário
            }
            
            return View(modelo); // Alguma coisa de errada aconteceu
        }

    }
}