using BusinessObject;
using System.Diagnostics.Metrics;

namespace DataAccess
{
    public class MemberDAO
    {
        private static List<MemberObject> members = new List<MemberObject>();

        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance 
        {
            get 
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        private bool IsEmailUnique(string email)
        {
            return !members.Any(m => m.email == email);
        }

        private bool IsPasswordStrong(string password)
        {
            // Implement your password strength validation logic here
            // For example, check minimum length, special characters, etc.
            return password.Length >= 8; // Example: Minimum 8 characters
        }

        private bool IsCityValid(string city)
        {
            // Implement city validation logic here
            // You can use a database or an external service to validate the city
            // For simplicity, let's assume any non-empty city is considered valid
            return !string.IsNullOrEmpty(city);
        }

        private bool IsCountryValid(string country)
        {
            // Implement country validation logic here
            // You can use a database or an external service to validate the country
            // For simplicity, let's assume any non-empty country is considered valid
            return !string.IsNullOrEmpty(country);
        }

        public List<MemberObject> GetMembers => members;

        public void AddMember(MemberObject member)
        {
            // Check if the provided member ID already exists
            if (GetMemberByID(member.id) != null)
            {
                throw new Exception("Member ID already exists!");
            }

            // Perform validations on the member object
            if (!IsEmailUnique(member.email))
            {
                throw new Exception("Email already exists!");
            }

            if (!IsPasswordStrong(member.password))
            {
                throw new Exception("Password is not strong enough!");
            }

            if (!IsCityValid(member.city))
            {
                throw new Exception("The city cannot be empty!");
            }

            if (!IsCountryValid(member.country))
            {
                throw new Exception("The country cannot be empty!");
            }

            // All validations passed, add the member to the list
            members.Add(member);
        }

        public void DeleteMember(int memberID)
        {
            MemberObject memberToDelete = GetMemberByID(memberID);
            if (memberToDelete != null)
            {
                members.Remove(memberToDelete);
            }
            else
            {
                // Handle the case when the member is not found
                // You can throw an exception or display an error message
                throw new Exception("Member does not exist!");
            }
        }

        public MemberObject GetMemberByID(int id)
        {
            MemberObject member = members.FirstOrDefault(mem => mem.id == id);
            return member;
        }

        public void UpdateMember(MemberObject updatedMember)
        {
            MemberObject existingMember = GetMemberByID(updatedMember.id);
            if (existingMember != null)
            {
                // Update the member details
                existingMember.name = updatedMember.name;

                // Check if the email is being changed
                if (!string.Equals(existingMember.email, updatedMember.email, StringComparison.OrdinalIgnoreCase))
                {
                    // Email is being changed, check if it is unique
                    if (IsEmailUnique(updatedMember.email))
                    {
                        existingMember.email = updatedMember.email;
                    }
                    else
                    {
                        throw new Exception("Email already exists!");
                    }
                }

                // Check the password and update if it meets the requirements
                if (IsPasswordStrong(updatedMember.password))
                {
                    existingMember.password = updatedMember.password;
                }
                else
                {
                    throw new Exception("Password is not strong enough!");
                }

                // Check the city and update if it is valid
                if (IsCityValid(updatedMember.city))
                {
                    existingMember.city = updatedMember.city;
                }
                else
                {
                    throw new Exception("The city cannot be empty!");
                }

                // Check the country and update if it is valid
                if (IsCountryValid(updatedMember.country))
                {
                    existingMember.country = updatedMember.country;
                }
                else
                {
                    throw new Exception("The country cannot be empty!");
                }
            }
            else
            {
                // Handle the case when the member is not found
                // You can throw an exception or display an error message
                throw new Exception("Cannot update member!");
            }
        }

        public List<MemberObject> FindMembersByName(string name)
        {
            // Use LINQ to query members by name
            List<MemberObject> foundMembers = members.Where(m => m.name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            return foundMembers;
        }

        public MemberObject FindMembersByEmail(string email)
        {
            MemberObject member = members.FirstOrDefault(mem => mem.email.Equals(email));

            return member;
        }

    }
}