using CRUD_Owners_RealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.DatabaseService
{
    public class DBOperations_Owners
    {
       
        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        private DbContextClass db = new DbContextClass();
        public bool InsertOwnerData(Owner ownerData, string imagePath = ownerDefaultImagePath)
        {
            ownerData.ImagePath = imagePath;
            //ownerData.EntryTime = DateTime.Now;
            db.Owners.Add(ownerData);
            int rowInserted = db.SaveChanges();

            return rowInserted > 0;
        }

        public bool UpdateOwnerData(Owner ownerData, string imagePath)
        {
            ownerData.ImagePath = imagePath;
            db.Entry(ownerData).State = EntityState.Modified;
            int rowsUpdated = db.SaveChanges();

            return rowsUpdated > 0;
        }

        public List<Owner> GetOwners()
        {
            return db.Owners.ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return db.Owners.Where(row => row.OwnerId == id).FirstOrDefault();
        }

    }
}