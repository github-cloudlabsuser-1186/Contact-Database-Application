using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Retrieve the list of users from the userlist and remove duplicates
            var users = userlist.Distinct();

            // Return the Index view with the list of users
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the Details view with the user
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Return the Create view
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the new user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the Edit view with the user
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Retrieve the user with the specified ID from the userlist
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the existing user's information with the new user's information
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here

            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
