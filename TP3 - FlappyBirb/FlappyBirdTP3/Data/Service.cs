namespace TP3FlappyBird.Data
{
    public class Service
    {
        protected readonly FlappyBirdContext _context;

        public Service(FlappyBirdContext context)
        {
            _context = context;
        }
    }
}
