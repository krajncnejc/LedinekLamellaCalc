partial class Program
{
    public class lamelGroup
    {
        public int lamPerWidthCount { get; set; }  //kolko lamel v širino
        public int lamPerLongCount { get; set; }  //kolko lamel v dolžini
        public int lamLength {  get; set; }  //dolžina lamele
        public int lamWidth { get; set; }  //širina lamele

        public int totalLamShort => lamPerWidthCount * lamPerLongCount;  //kolko lamel skupaj
        public int totalLamLong => lamPerWidthCount;  //koliko dolgih plošč
        public int longLenght => lamPerLongCount * lamLength; //dolžina dolge lamele
        public int groupWidth => lamPerWidthCount * lamWidth;  //širina vseh lamel v skupini
    }
}