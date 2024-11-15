using TMPro;
using UnityEngine;

public enum Button1
{
    mutation1, mutation2, mutation3, mutation4//, mutation5
}
public enum Button2
{
    mutation1, mutation2, mutation3, mutation4//, mutation5
}
public enum Button3
{
    mutation1, mutation2, mutation3, mutation4//, mutation5
}
public class MutationRoll : MonoBehaviour
{
    public TMP_Text button_Text1;
    public TMP_Text button_Text2;
    public TMP_Text button_Text3;
    public Button1 mutationButton1;
    public Button2 mutationButton2;
    public Button3 mutationButton3;

    MutationsManager mutationsManager;

    private void Start()
    {
        mutationsManager = FindObjectOfType<MutationsManager>();
    }

    public void RandomizeButtons()
    {
        int m = Random.Range(0, MutationsManager.Instance.Mutations.Length);
        int storage = m;
        int storage1 = storage;
            switch (m)
            {
                case 0:
                    button_Text1.text = "Invert Camera";
                    mutationButton1 = Button1.mutation1;
                    break;
                case 1:
                    button_Text1.text = "Lag";
                    mutationButton1 = Button1.mutation2;
                    break;
                case 2:
                    button_Text1.text = "Invisible Player";
                    mutationButton1 = Button1.mutation3;
                    break;
                    
                case 3:
                    button_Text1.text = "Crash";
                    mutationButton1 = Button1.mutation4;
                    break;
                    /*
                case 4:
                    button_Text.text = "Mutation 5";
                    mutation = Mutation.mutation5;
                    break;
                    */
            }
            while (storage == m)
            {
                m = Random.Range(0, MutationsManager.Instance.Mutations.Length);
            }
            storage1= m;
            switch (m)
            {
                case 0:
                    button_Text2.text = "Invert Camera";
                    mutationButton2 = Button2.mutation1;
                    break;
                case 1:
                    button_Text2.text = "Lag";
                    mutationButton2 = Button2.mutation2;
                    break;
                case 2:
                    button_Text2.text = "Invisible Player";
                    mutationButton2 = Button2.mutation3;
                    break;
                    
                case 3:
                    button_Text2.text = "Crash";
                    mutationButton2 = Button2.mutation4;
                    break;
                    /*
                case 4:
                    button_Text.text = "Mutation 5";
                    mutation = Mutation.mutation5;
                    break;
                    */
        }
        while (m == storage || m == storage1)
            {
                m = Random.Range(0, MutationsManager.Instance.Mutations.Length);
            }
            switch (m)
            {
                case 0:
                    button_Text3.text = "Invert Camera";
                    mutationButton3 = Button3.mutation1;
                    break;
                case 1:
                    button_Text3.text = "Lag";
                    mutationButton3= Button3.mutation2;
                    break;
                case 2:
                    button_Text3.text = "Invisible Player";
                    mutationButton3 = Button3.mutation3;
                    break;
                    
                case 3:
                    button_Text3.text = "Crash";
                    mutationButton3 = Button3.mutation4;
                    break;
                    /*
                case 4:
                    button_Text.text = "Mutation 5";
                    mutation = Mutation.mutation5;
                    break;
                    */
        }
    }

    public void Mutate1()
    {
            switch (mutationButton1)
            {
                case Button1.mutation1:
                    if (mutationsManager.mutation1)
                    {
                        MutationsManager.Instance.Mutations[0].SetActive(false);
                        mutationsManager.mutation1 = false;
                    }
                    else
                    {
                        MutationsManager.Instance.Mutations[0].SetActive(true);
                        mutationsManager.mutation1 = true;
                    }
                break;

                case Button1.mutation2:
                if (mutationsManager.mutation2)
                {
                    MutationsManager.Instance.Mutations[1].SetActive(false);
                    mutationsManager.mutation2 = false;
                }
                else
                {
                    MutationsManager.Instance.Mutations[1].SetActive(true);
                    mutationsManager.mutation2 = true;
                }
                break;

                case Button1.mutation3:

                if (mutationsManager.mutation3)
                {
                    MutationsManager.Instance.Mutations[2].SetActive(false);
                    mutationsManager.mutation3 = false;
                }
                else
                {
                    MutationsManager.Instance.Mutations[2].SetActive(true);
                    mutationsManager.mutation3 = true;
                }

                break;
                
                case Button1.mutation4:

                if (mutationsManager.mutation4)
                {
                    MutationsManager.Instance.Mutations[3].SetActive(false);
                    mutationsManager.mutation4 = false;
                }
                else
                {
                    MutationsManager.Instance.Mutations[3].SetActive(true);
                    mutationsManager.mutation4 = true;
                }

                break;
                /*
                case Mutation.mutation5:
                    MutationsManager.Instance.Mutations[4].SetActive(true);
                break;*/
        }
        MutationsManager.Instance.RefreshAll.Invoke();
    }

    public void Mutate2()
    {
        switch (mutationButton2)
        {
            case Button2.mutation1:
                MutationsManager.Instance.Mutations[0].SetActive(true);
                break;

            case Button2.mutation2:
                MutationsManager.Instance.Mutations[1].SetActive(true);
                break;

            case Button2.mutation3:
                MutationsManager.Instance.Mutations[2].SetActive(true);
                break;
                
                case Button2.mutation4:
                    MutationsManager.Instance.Mutations[3].SetActive(true);
                break;
                /*
                case Mutation.mutation5:
                    MutationsManager.Instance.Mutations[4].SetActive(true);
                break;*/
        }
        MutationsManager.Instance.RefreshAll.Invoke();
    }

    public void Mutate3()
    {
        switch (mutationButton3)
        {
            case Button3.mutation1:
                MutationsManager.Instance.Mutations[0].SetActive(true);
                break;

            case Button3.mutation2:
                MutationsManager.Instance.Mutations[1].SetActive(true);
                break;

            case Button3.mutation3:
                MutationsManager.Instance.Mutations[2].SetActive(true);
                break;
                
                case Button3.mutation4:
                    MutationsManager.Instance.Mutations[3].SetActive(true);
                break;
                /*
                case Mutation.mutation5:
                    MutationsManager.Instance.Mutations[4].SetActive(true);
                break;*/
        }
        MutationsManager.Instance.RefreshAll.Invoke();
    }
}
