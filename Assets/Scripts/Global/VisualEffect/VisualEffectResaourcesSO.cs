using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Madicine.Global.Vfx
{
    
    [CreateAssetMenu(fileName = "VisualEffectListResaources", menuName = "VFXList/VisualEffectResaources", order = 0)]
    public class VisualEffectResaourcesSO : ScriptableObject {
        
        public List<VFXObject> effect;

        public GameObject FindVFX(VisualEffectEnum vfx){
            VFXObject objvfx = new VFXObject();
            GameObject obj = new GameObject();
            objvfx = effect.Find( v => v.nama == vfx);
            return obj = objvfx.obnjectVFX;
        }
    }

    

}