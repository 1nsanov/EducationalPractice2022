using Newtonsoft.Json;

namespace Task_14_04
{
    public class HexCounterManager
    {
        private int curIdx { get; set; }
        public List<HexadecimalCounter> hexadecimalCounterList { get; set; }

        public HexCounterManager()
        {
            curIdx = -1;
            hexadecimalCounterList = new List<HexadecimalCounter>();
        }

        public void DefaultLoad(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
        }
        public string ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                hexadecimalCounterList = JsonConvert.DeserializeObject<List<HexadecimalCounter>>(File.ReadAllText(path));
                return "File loaded";
            }
            else return "File not found";
        }
        public string WriteToFile(string path)
        {
            if (hexadecimalCounterList != null)
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(hexadecimalCounterList));
                return "File saved";
            }
            else return "List is null";
        }
        public void AddCounter(int value, int maxV, int minV)
        {
            hexadecimalCounterList.Add(HexadecimalCounter.SetValue(value, maxV, minV));
        }
        public void AddCounter()
        {
            hexadecimalCounterList.Add(new HexadecimalCounter());
        }
        public void SetCurrentIndex(string id)
        {
            curIdx = hexadecimalCounterList.FindIndex(x => x.Id == id);
        }
        public void SetCurrentIndex(int idx)
        {
            curIdx = idx;
        }
        public bool IsSelectIdx()
        {
            if (curIdx == -1) return false;
            return true;
        }
        public string GetCurrentValues()
        {
            if (hexadecimalCounterList[curIdx] != null) return hexadecimalCounterList[curIdx].PrintValues();
            else return "List is null";
        }
        public string IncrementCurrent()
        {
            return hexadecimalCounterList[curIdx].Increment();
        }
        public string DecrementCurrent()
        {
            return hexadecimalCounterList[curIdx].Decrement();
        }
        public string[] GetForEditCounter()
        {
            return new string[] {
                HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].Value).ToString(),
                HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].MaxValue).ToString(),
                HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].MinValue).ToString()
            };
        }
        public void EditCurrent(string value, string maxV, string minV)
        {
            hexadecimalCounterList[curIdx].Value = value;
            hexadecimalCounterList[curIdx].MaxValue = maxV;
            hexadecimalCounterList[curIdx].MinValue = minV;
        }
        public void RemoveCurrent()
        {
            hexadecimalCounterList.RemoveAt(curIdx);
            curIdx = -1;
        }
    }
}
