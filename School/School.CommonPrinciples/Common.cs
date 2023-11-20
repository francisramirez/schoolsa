

namespace School.CommonPrinciples
{
    public static class Common
    {
        public static string GetMonthName(int month)
        {
            string monthName = string.Empty;


            switch (month)
            {
                case 1:
                    monthName = "January";
                   
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
                default:
                    break;
            }

            return monthName;
        }

        public static string GetMonthNameArray(int month)
        {
            
            
            if (month < 1 || month >12)
                throw new InvalidOperationException("Mi mensaje");

            
            
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            return months[month - 1];
        
        }


    }


}
