using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;

namespace Generator_testova
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {

        }

      

    }
}

/*public void Qupdate(int ID)
{
    using (GeneratorDBContext db = new GeneratorDBContext())
    {
        Question item = null;
        item = db.Questions.Find(ID);
        if (item == null)
        {
            ModelState.AddModelError("",
              String.Format("Item with id {0} was not found", ID));
            return;
        }

        TryUpdateModel(item);
        if (ModelState.IsValid)
        {
            db.SaveChanges();
        }
    }
}

public void Qdelete(int ID)
{
    using (GeneratorDBContext db = new GeneratorDBContext())
    {
        var item = new Question { ID = ID };
        db.Entry(item).State = System.Data.EntityState.Deleted;
        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            ModelState.AddModelError("",
              String.Format("Item with id {0} no longer exists in the database.", ID));
        }
    }
}*/