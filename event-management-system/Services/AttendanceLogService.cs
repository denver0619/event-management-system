using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class AttendanceLogService : IDisposable
    {
        private TimeInRepository _timeInRepository;
        private TimeOutRepository _timeOutRepository;
        private TicketRepository _ticketRepository;
        private StudentRepository _studentRepository;
        public AttendanceLogModel Model { get; set; }

        public AttendanceLogService(string eventID)
        {
            _timeInRepository = new TimeInRepository();
            _timeOutRepository = new TimeOutRepository();
            _ticketRepository = new TicketRepository();
            _studentRepository = new StudentRepository();
            Model = new AttendanceLogModel();
            Model = GetAllStudentAttendee(eventID);
        }
        public AttendanceLogModel GetAllStudentAttendee(string eventID)
        {
            List<ITicket> tickets = _ticketRepository.GetByEventID(eventID);
            List<TimeInDataTransferObject> timeInList = new List<TimeInDataTransferObject>();
            List<TimeOutDataTransferObject> timeOutList = new List<TimeOutDataTransferObject>();
            foreach(ITicket ticket in tickets)
            {
                IStudent student = _studentRepository.GetByID(ticket.StudentID!);
                ITimeInEntity timeInEntity = _timeInRepository.GetTimeInByTicketID(ticket.TicketID!);
                ITimeOutEntity timeOutEntity = _timeOutRepository.GetTimeOutByTicketID(ticket.TicketID!);
                TimeInDataTransferObject timeIn = new TimeInDataTransferObject(timeInEntity);
                TimeOutDataTransferObject timeOut = new TimeOutDataTransferObject(timeOutEntity);
                timeIn.Student = student;
                timeIn.Ticket = ticket;
                timeOut.Student = student;
                timeOut.Ticket = ticket;
                timeInList.Add(timeIn);
                timeOutList.Add(timeOut);
            }
            Model.TimeInList = timeInList;
            Model.TimeOutList = timeOutList;
            return Model;
        }

        public void TimeOut(ITimeOutEntity timeOut)
        {
            _timeOutRepository.UpdateTimeOut(timeOut);
        }

        public void TimeIn(ITimeInEntity timeIn)
        {
            _timeInRepository.UpdateTimeIn(timeIn);
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
            _timeOutRepository.Dispose();
            _timeInRepository.Dispose();
            _ticketRepository.Dispose();
        }
    }
}
