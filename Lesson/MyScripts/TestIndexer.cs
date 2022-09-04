public class TestIndexer
{
        private string[] nameList;

        public TestIndexer()
        {
                int size = 10;
                nameList = new string[size];
                for (int i = 0; i < nameList.Length; i++)
                {
                        nameList[i] = i.ToString();
                }
        }

        public string this[int index]
        {
                get
                {
                        if (index >= 0 && index < nameList.Length)
                        {
                                return nameList[index];
                        }

                        return "";
                }
                set
                {
                        if (index >= 0 && index < nameList.Length)
                        {
                                nameList[index] = value;
                        }   
                }
        }
}