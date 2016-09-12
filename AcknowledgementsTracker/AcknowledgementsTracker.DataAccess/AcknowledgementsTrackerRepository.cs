namespace AcknowledgementsTracker.DataAccess
{
    using System;
    using System.Collections.Generic;
    using Model.Models;

    public class AcknowledgementsTrackerRepository
    {
        public void SaveAcknowledgement(string text, int employeeId, List<int> tagIds)
        {
            var acknowledgement = new Acknowledgement()
            {
                Text = text,
                DateCreated = DateTime.Now,
                ProxiadEmployeeId = employeeId,
                TagIds = tagIds
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void SaveProxiadEmployee(string userName, string email)
        {
            var employee = new ProxiadEmployee()
            {
                UserName = userName,
                Email = email
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ProxiadEmployees.Add(employee);
                context.SaveChanges();
            }
        }

        public void SaveTag(string title)
        {
            var tag = new Tag()
            {
                // Possible change
                Title = $"#{title}"
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void DeleteAcknowledgement()
        {
            // TODO:
        }

        public void DeleteProxiadEmployee()
        {
            // TODO:
        }

        public void DeleteTag()
        {
            // TODO:
        }

        public void EditAcknowledgement()
        {
            // TODO:
        }

        public void EditProxiadEmployee()
        {
            // TODO:
        }

        public void EditTag()
        {
            // TODO:
        }
    }
}
