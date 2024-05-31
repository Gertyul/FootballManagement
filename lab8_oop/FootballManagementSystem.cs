    public class FootballManagementSystem
    {
        private PlayerManagement playerManagement = new PlayerManagement();
        private GameManagement gameManagement = new GameManagement();
        private StadiumManagement stadiumManagement = new StadiumManagement();

        public PlayerManagement PlayerManagement => playerManagement;
        public GameManagement GameManagement => gameManagement;
        public StadiumManagement StadiumManagement => stadiumManagement;
    }


