using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenService
{
    public class ActivityService
    {
        private ActivityDao activityDao;

        public ActivityService()
        {
            activityDao = new();
        }

        public List<Activity> GetActivities()
        {
            return activityDao.GetAll();
        }

        public List<Activity> GetActivitiesForParticipant(Student student)
        {
            return activityDao.GetActivitiesForParticipant(student);
        }

        public bool CheckStudentInActivity(Student student, Activity activity)
        {
            List<Activity> activityList = GetActivitiesForParticipant(student);

            foreach (Activity act in activityList)
            {
                if (act.StartDayTime == activity.StartDayTime)
                {
                    return false;
                }
            }
            return true;
        }
    }
}