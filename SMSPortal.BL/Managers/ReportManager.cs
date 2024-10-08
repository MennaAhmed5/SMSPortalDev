﻿using SMSPortal.BL.ViewModels.MessageTempletes;
using SMSPortal.BL.ViewModels.Reports;
using SMSPortal.DAL.Data.Models;
using SMSPortal.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMSPortal.BL.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddReport(ReportAddVM reportAddVM)
        {
            Report report= new Report()
            {
                 SenderUsername = reportAddVM.SenderUsername,
                 PhoneNumber = reportAddVM.PhoneNumber,
                 MessageContent = reportAddVM.MessageContent,                 
                 Status = reportAddVM.Status,
                 Details = reportAddVM.Details,
                 
            };

            _unitOfWork.ReportRepository.Add(report);
            _unitOfWork.SaveChanges();
        }

        public object Delete(int id)
        {
            var report = _unitOfWork.ReportRepository.GetById(id);
            if (report == null) return new { success = false, message = "Error While Deleting " };
            _unitOfWork.ReportRepository.Delete(report);
            _unitOfWork.SaveChanges();
            return new { success = true, message = "report has been Deleted " };
        }

        public void Edit(ReportEditVM reportEditVM)
        {
            var report = _unitOfWork.ReportRepository.GetById(reportEditVM.Id);
            report.SenderUsername = reportEditVM.SenderUsername;
            report.MessageContent = reportEditVM.MessageContent;
            report.PhoneNumber = reportEditVM.PhoneNumber;
            report.Status = reportEditVM.Status;
            report.Details = reportEditVM.Details;
           
            _unitOfWork.ReportRepository.Update(report);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ReportReadVM> GetAll()
        {
            IEnumerable<Report> reports = _unitOfWork.ReportRepository.GetAll();
            IEnumerable<ReportReadVM> reportsReadVM = reports.Select(r=> new ReportReadVM(r.Id, r.SenderUsername, r.PhoneNumber, r.MessageContent, r.SendingDate, r.Status, r.Details));
            return reportsReadVM;
        }

        public ReportDetailsVM? GetDetailsById(int id)
        {
            var report = _unitOfWork.ReportRepository.GetById(id);
            if (report == null)
            {
                return null;
            }
            else
            {
                return new ReportDetailsVM(report.Id, report.SenderUsername, report.PhoneNumber, report.MessageContent, report.SendingDate, report.Status, report.Details);
                    
            }
        }

        public ReportEditVM? GetforEditById(int id)
        {
            var report = _unitOfWork.ReportRepository.GetById(id);
            if (report== null) return null;
            return new ReportEditVM(report.Id, report.SenderUsername, report.PhoneNumber, report.MessageContent, report.Status, report.Details);
        }

        public IEnumerable<ReportReadVM> GetFilteredReports(string userName, string number)
        {
            var reports = _unitOfWork.ReportRepository.GetAll();

            if (!string.IsNullOrEmpty(userName))
            {
                reports = reports.Where(r => r.SenderUsername.Contains(userName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(number))
            {
                reports = reports.Where(r => r.PhoneNumber.Contains(number));
            }

            IEnumerable<ReportReadVM> reportsReadVM = reports.Select(r => new ReportReadVM(r.Id, r.SenderUsername, r.PhoneNumber, r.MessageContent, r.SendingDate, r.Status, r.Details));
            return reportsReadVM;
        }
    }
}
