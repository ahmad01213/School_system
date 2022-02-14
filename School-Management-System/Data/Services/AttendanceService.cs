using Microsoft.EntityFrameworkCore;
using School_Management_System.Data.Base;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly AppDbContext _context;

        public AttendanceService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<AttendanceDetail>> SearchAllAsync(int SchoolId, DateTime Date)
        {

            List<AttendanceDetail> attendances = new List<AttendanceDetail>();
            IEnumerable<Teatcher> Teatchers = await _context.Teatchers.Where(x => x.SchoolId == SchoolId).ToListAsync();
            foreach (var teacher in Teatchers)
            {
                int AttendanceStatus = GetAbsenceStatus(teacher,Date);
                AttendanceDetail attendanceDetail = new AttendanceDetail()
                {
                    Teatcher = teacher,
                    Status = AttendanceStatus
                };
            }
            return attendances;
        }



        public  int GetAbsenceStatus(Teatcher teatcher,DateTime Date)
        {
            string DayOfWeek = Date.DayOfWeek.ToString();
            TimeTable timeTable = _context.TimeTables.Where(x => x.TeatcherId == teatcher.Id && x.Dayofweek == DayOfWeek).FirstOrDefault();
            if (timeTable == null)
            {
                return 4;
            }
            string inTime = timeTable.InTime;
            string outTime = timeTable.OutTime;
            List<Attendance> attendances =_context.Attendances.Where(x=>x.Date.Date.ToShortDateString()==Date.ToShortDateString()).ToList();
            if (attendances.Count == 0)
            {
                return 3;
            }
            else if(attendances.Count == 1)
            {
                int Hour = attendances[0].Date.Hour;
                int Minut = attendances[0].Date.Minute;
                int TableTimeHour = int.Parse(inTime.Split(":")[0]);
                int TableTimeMinut = int.Parse(inTime.Split(":")[0]);

                if (Hour > TableTimeHour) {
                    return 3;
                }
                else
                {
                    if (Minut>TableTimeMinut+timeTable.Permittime) {
                        return 2;
                    }
                    return 1;
                }
            }
            else if (attendances.Count >=2)
            {
                int InHour = attendances[0].Date.Hour;
                int InMinut = attendances[0].Date.Minute;

                int OutHour = attendances[1].Date.Hour;
                int OutMinut = attendances[1].Date.Minute;


                int InTableTimeHour = int.Parse(inTime.Split(":")[0]);
                int InTableTimeMinut = int.Parse(inTime.Split(":")[0]);

                int OutTableTimeHour =   int.Parse(outTime.Split(":")[0]);
                int OutTableTimeMinut = int.Parse(outTime.Split(":")[0]);

                return 1;
            }
            return 1;
        }
    }
}
