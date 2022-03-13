namespace GRHWLibrary
{
    /// <summary>
    /// SomeData is a generic name 
    /// because the data contained therein lacks a cohesive purpose 
    /// which would normally be used to provide a more meaningful name
    /// </summary>
    public class SomeData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            string emptyString = "[empty]";
            return $"{LastName??emptyString},{FirstName??emptyString},{Email??emptyString},{FavoriteColor??emptyString},{DateOfBirth.ToString("M/d/yyyy")}";
        }
    }
}
