namespace MvcProject.Helpers
{
    public class AutoGenerateId
    {
        public string GenerateId(string lastId)
        {
            // Nếu lastId không hợp lệ thì trả về PS1
            if (string.IsNullOrEmpty(lastId) || !lastId.StartsWith("PS"))
                return "PS1";

            // Tách phần số ra khỏi lastId
            string numberPart = lastId.Substring(2);
            if (int.TryParse(numberPart, out int number))
            {
                return "PS" + (number + 1);
            }

            // Nếu không parse được, trả về mặc định
            return "PS1";
        }
    }
}
