namespace Model
{
    [System.Serializable]
    public class HeroicDeed
    {
        public hdtype Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Received
        {
            get { return received; }
            set { received = value; }
        }

        public bool Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }

        private hdtype type;
        private bool received;
        private bool confirmed;


        
        
        
        public enum hdtype{
            startingcrew1,
            startingcrew2,
            startingcrew3,
            aegisofzeus,
            apollobow,
            ambrosia,
            daedaluswing,
            zeus_blessing1,
            zeus_blessing2,
            apollo_blessing1,
            apollo_blessing2,
        }
        
        
        public int GetPrice(){
            switch (this.type){
                case hdtype.startingcrew1:
                    return 1;
                case hdtype.startingcrew2:
                    return 2;
                case hdtype.startingcrew3:
                    return 3;
                case hdtype.aegisofzeus:
                    return 2;
                case hdtype.apollobow:
                    return 2;
                case hdtype.ambrosia:
                    return 2;
                case hdtype.daedaluswing:
                    return 2;
                default:
                    return 1;	
            }	
        }	

    }
}