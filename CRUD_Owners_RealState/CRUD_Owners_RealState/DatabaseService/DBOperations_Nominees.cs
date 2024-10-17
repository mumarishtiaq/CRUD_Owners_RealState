using CRUD_Owners_RealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.DatabaseService
{
    public class DBOperations_Nominees
    {
        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        private DbContextClass db = new DbContextClass();
        public bool InsertNomineeData(Nominee nominee, string imagePath = ownerDefaultImagePath)
        {
            nominee.ImagePath = imagePath;
            //ownerData.EntryTime = DateTime.Now;
            db.Nominees.Add(nominee);
            int rowInserted = db.SaveChanges();

            return rowInserted > 0;
        }

        public bool UpdateNomineeData(Nominee nominee, string imagePath)
        {
            nominee.ImagePath = imagePath;
            db.Entry(nominee).State = EntityState.Modified;
            int rowsUpdated = db.SaveChanges();

            return rowsUpdated > 0;
        }

        public List<Nominee> GetNominees()
        {
            return db.Nominees.ToList();
        }

        public Nominee GetNomineeById(int id)
        {
            return db.Nominees.Where(row => row.NomineeId == id).FirstOrDefault();
        }
        public List<Nominee> GetNomineeByOwnerId(int ownerId)
        {
            return db.Nominees.Where(n => n.OwnerId == ownerId).ToList();
        }
    }
}