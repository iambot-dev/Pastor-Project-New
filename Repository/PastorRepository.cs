using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PASTORALISPROJECTNEW.DBContext;
using PASTORALISPROJECTNEW.Models;
using PASTORALISPROJECTNEW.RequestModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PASTORALISPROJECTNEW.Repository
{
    public class PastorRepository : IPastorRepository
    {
        private readonly PastoralisDBContext _context;

        public PastorRepository(PastoralisDBContext context)
        {
            this._context = context;
        }

        public List<Pastor> GetAllAavailablePastors()
        {
            List<Pastor> availablePastor = _context.Slots.Where(s => s.
            IsAvailable == true).Select
            (s => s.Pastor).ToList();
            return availablePastor;
        }

        public IEnumerable<Slot> GetAllAvailableSlotsOfAParticularPastorById(int id)
        {
            // Getting the pastor from the database
            Pastor pastor = _context.Pastors.FirstOrDefault(p => p.Id == id);
            if (pastor == null)
            {
                return Enumerable.Empty<Slot>();
            }

            // Checking if there are any existing Slots
            Slot firstSlot = _context.Slots.OrderBy(s => s.StartTime).FirstOrDefault();
            if (firstSlot == null || !firstSlot.StartTime.HasValue || !firstSlot.EndTime.HasValue)
            {
                return Enumerable.Empty<Slot>();
            }

            // Null check for duration
            int? duration = pastor?.Duration;
            if (duration == null)
            {
                return Enumerable.Empty<Slot>();
            }

            DateTime startTime = firstSlot.StartTime.Value;
            DateTime endTime = firstSlot.EndTime.Value;

            // Calculating the total time and number of slots here
            double totalTime = (endTime - startTime).TotalMinutes;
            int numberOfSlots = (int)(totalTime / duration.Value);

            // Creating the list to store into the available slots
            List<Slot> availableSlots = new List<Slot>();

            // Generating The Slots Here
            for (int i = 0; i < numberOfSlots; i++)
            {
                Slot slot = new Slot
                {
                    // Id = (i + 1),
                    PastorId = pastor.Id,
                    SlotDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    StartTime = startTime.AddMinutes(i * duration.Value),
                    EndTime = startTime.AddMinutes((i + 1) * duration.Value),
                    IsAvailable = true,
                    IsClosed = false,
                    Bookingevents = new List<Bookingevent>(),
                };
                availableSlots.Add(slot);
            }

            // Saving Slots to the database 
            _context.Slots.AddRange(availableSlots);
            _context.SaveChanges();

            return availableSlots;
        }

        public IEnumerable<Pastor> GetAllPastors()
        {
           return _context.Pastors.ToList();
        }

        public Pastor GetPastorById(int id)
        {
            return _context.Pastors.FirstOrDefault(p => p.Id == id);
        }

        public string SetAvailbilityForSlotsByPastorId(int id,DateOnly date ,  String? starttime, String? endtime, bool isAvailable)
        {
            //Check if the pastor with the given ID exists in the database.
            var pastor = _context.Pastors.FirstOrDefault(p => p.Id == id);
            if (pastor == null)
            {
                // If pastor not found, return an error message.
                return $"Pastor for id:{id} not found";
            }

            // Parse start time and end time strings to TimeSpan.
            if (!TimeSpan.TryParse(starttime, out var parsedStartTime) ||
                !TimeSpan.TryParse(endtime, out var parsedEndTime))
            {
                // If parsing fails, return an error message.
                return "Invalid start time or end time format";
            }

            // Create a new Slot instance with the provided parameters.
            var availability = new Slot
            {
                PastorId = id,

                SlotDate = date,

                StartTime = DateTime.UtcNow.Date.Add(parsedStartTime),

                EndTime = DateTime.UtcNow.Date.Add(parsedEndTime),

                // Set the availability status.
                IsAvailable = isAvailable,
            };

            //Add the new availability record to the Slots table.
            _context.Slots.Add(availability);

            // Save changes to the database.
            _context.SaveChanges();

            // Return a success message.
            return $"Availability set successfully for Pastor {pastor.Id}";
        }

        string IPastorRepository.SetDurationForSlotByPastorId(int id, int duration)
        {
            // Check if the pastor with the given ID exists in the database.
            var pastor = _context.Pastors.FirstOrDefault(p => p.Id == id);
            if (pastor == null)
            {
                //If pastor not found, return an error message.
                return $"Pastor for id:{id} not found";
            }

            // Set the duration for the pastor.
            pastor.Duration = duration;

            //Save changes to the database.
            _context.SaveChanges();

            // Return a success message.
            return "Duration set successfully";
        }

        public string ChnagePasswordForPastor(int pastorId, ChangePassword passmodel)
        {
            var userEntityAccess = _context.Userentityaccesses.FirstOrDefault(u => u.EntityId == pastorId && u.EntityType == 2 );
            if (userEntityAccess == null)
            {
                throw new InvalidOperationException($"User entity access record not found for Pastor ID: {pastorId}");
            }
            var user = _context.Users.Find(userEntityAccess.UserId);
            if (user == null)
            {
                throw new InvalidOperationException($"User record not found for Pastor ID: {pastorId}");
            }
            user.Password = new PasswordHasher<User>().HashPassword(user, passmodel.ConfirmPassword);
            user.UpdatedDate = DateTime.UtcNow; 
            _context.Update(user);
            _context.SaveChanges();
            return "Password Changed Successfully";
        }
    }
}
