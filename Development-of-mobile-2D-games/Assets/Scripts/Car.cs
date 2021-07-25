namespace Profile
{
    public class Car : IUpgradableCar
    {
        private readonly float _defaultSpeed;

        #region Life cycle
        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }
        #endregion
        #region IUpgradableCar
        public float Speed { get; set; }
        public void Restore()
        {
            Speed = _defaultSpeed;
        }
        #endregion
    }
}
