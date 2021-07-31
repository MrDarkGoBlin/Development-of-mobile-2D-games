using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Update(DataPlayer dataPlayer, DataType dataType);

    void ChangeTypeButtle(TypeButtle typeButtle);
}
