namespace WebAspNetPractica_26_06_2024
{
    public class MountainPeaks
    {
        public int id {  get; set; }
        public string mountainSystem { get; set; }
        public string mountainName {  get; set; }
        public int mountainHeight { get; set; }
        public string countryName { get; set;}
    
    public MountainPeaks() { }
        public override string ToString()
        {
            return ($"{id} - {mountainSystem} - {mountainName} - {mountainHeight} - {countryName}");
        }
    }
}
