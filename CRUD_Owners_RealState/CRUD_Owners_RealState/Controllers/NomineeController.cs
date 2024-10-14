﻿using CRUD_Owners_RealState.BLL;
using CRUD_Owners_RealState.DatabaseService;
using CRUD_Owners_RealState.GlobalMethods;
using CRUD_Owners_RealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Owners_RealState.Controllers
{
    public class NomineeController : Controller
    {
        private ImageValidation _imageValidation = new ImageValidation();
        private DBOperations_Nominees _dbOperations = new DBOperations_Nominees();
        public ActionResult AddNominee(int ownerID)
        {
            ViewBag.RelationTypes = HelperMethods.GetListFromEnum<RelationType>();
            Nominee nominee = new Nominee {
                Name = "Name",
                CNIC = "45454",
                Relation = "Friend",
                //Relation = RelationType.Friend,
                SODOWO = "So/Do/Wo",
                DOB = DateTime.Now,
                CellNo = "5644",
                Gender  = "Male",
                Address = "jhfudb hf ",
                ImagePath = "~/SystemImages/NoUserImage.png",
                OwnerId = ownerID
            };

          
            
            return View(nominee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddNominee(Nominee nominee)
        {


            if (ModelState.IsValid)
            {
                if (nominee.ImageFile != null)
                {
                    //image validaton logic (checks for prefered extension and size)
                    if (_imageValidation.IsValidImage(nominee.ImageFile))
                    {
                        var path = _imageValidation.SaveImageOnServer(nominee.ImageFile);
                        var isDataInserted = _dbOperations.InsertNomineeData(nominee, path);


                        ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }
                else
                {
                    var isDataInserted = _dbOperations.InsertNomineeData(nominee);

                    ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                }
                //return RedirectToAction("AddNominee", "Nominee", new { id = ownerData.OwnerId });

            }
            ViewBag.RelationTypes = HelperMethods.GetListFromEnum<RelationType>();
            ModelState.Clear();
            return View();
        }
    }

}