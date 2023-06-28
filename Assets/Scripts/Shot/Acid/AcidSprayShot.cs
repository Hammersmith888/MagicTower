using UnityEngine;

public class AcidSprayShot : SpellBase
{
    public float lifeTime; // Время жизни заряда
    public int countAcidStrikes; // Количество зарядов в одном выстреле
    public int angle; // Угол под которые выстреливают заряды
    public GameObject strike; // Префаб шара выстрела
    public int minDamage, maxDamage; // min-max урон
    public float speed; // Скорость полета
    public int acidChance; // Вероятность эффекта отравления
    public int acidDamage; // Урон от эффекта отравления
    public float acidTime; // Длительность эффекта отравления

    private Vector3 targetDirection;
    private int damage;

    private float speedValue;

    // Активируется после получения вектора направления движения
    public void Activation(Vector3 _startPosition, Vector3 _targetDirection)
    {

        // Если начало вектора (координата x) направления движения находится в левой части от начальной точки движения
        if (_targetDirection.x < _startPosition.x)
        {
            _targetDirection = new Vector3( -_targetDirection.x, _targetDirection.y, _targetDirection.z);
        }

        targetDirection = _targetDirection - _startPosition; // Разница между точкой выстрела и точкой касания
        int sourceAngle = Mathf.RoundToInt(Mathf.Rad2Deg * Mathf.Atan2(targetDirection.y, targetDirection.x)); // Угол на который повернута ось (середина) конуса выстрела относительно точки выстрела
        sourceAngle += (angle / 2); // Начальный угол, от которого рассчитываем угол-шаг с которым выстреливают заряды
        int deltaAngle = (angle / (countAcidStrikes - 1)); // Угол-шаг, который прибавляем для каждого следующего заряда

        // Для каждого заряда
        for (int i = 0; i < countAcidStrikes; i++)
        {
			// Рассчитываем направление
			//float delta = Mathf.Sqrt( targetDirection.x * targetDirection.x + targetDirection.y * targetDirection.y );
            targetDirection = new Vector3( Mathf.Cos(Mathf.Deg2Rad * sourceAngle), Mathf.Sin(Mathf.Deg2Rad * sourceAngle), 0f);
            //targetDirection = new Vector3(targetDirection.x * 100, targetDirection.y * 100, 0); // Обнуляем координату Z

            // Угол на который выстреливает текущий заряд. Изменяем после рассчета направления, т.к. выстреливать начинаем с начального угла sourceAngle
            sourceAngle -= deltaAngle;             

            // Рассчитываем случайный урон и скорость
            damage = Random.Range(minDamage, maxDamage);
            speedValue = GAME_FIELD_WIDTH_IN_UNITS / (speed / 10);

            // Создаем объект, задаем родительский объект, устанавливаем параметры
            GameObject strikeObject = Instantiate(strike, _startPosition, Quaternion.identity) as GameObject;
            //strikeObject.transform.SetParent(transform);
            strikeObject.GetComponent<AcidShot>().SetAcidShotParam( targetDirection, speedValue, damage, acidChance, acidDamage, acidTime);

			Destroy( gameObject );
		}
    }
}