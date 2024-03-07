using UnityEngine;

[System.Serializable]
public class ViewOperator<TPrefab> where TPrefab : View {
    [SerializeField] private TPrefab prefab;
    [SerializeField] protected Transform viewParent;
    protected TPrefab view;

    public virtual void CreateView(){
        view = Object.Instantiate(prefab, viewParent);
    }
    
    public virtual void CreateViewClosed(){
        CreateView();
        view.Close();
    }

    public virtual void DestroyView(){
        Object.Destroy(view.gameObject);
    }

}