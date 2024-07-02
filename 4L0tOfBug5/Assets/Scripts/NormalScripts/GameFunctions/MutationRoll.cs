using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum Mutation
{
    mutation1, mutation2, mutation3, mutation4, mutation5
}
public class MutationRoll : MonoBehaviour
{
    public TMP_Text button_Text;
    Mutation mutation;
    public void Randomize()
    {
        int m = Random.Range(0, MutationsManager.Instance.Mutations.Length);
        for (int i = 0; i <= 3; ++i)
        {
            switch (m)
            {
                case 0:
                    button_Text.text = "Invert Camera";
                    mutation = Mutation.mutation1;
                    break;
                case 1:
                    button_Text.text = "Lag";
                    mutation = Mutation.mutation2;
                    break;
                case 2:
                    button_Text.text = "Invisible Player";
                    mutation = Mutation.mutation3;
                    break;
                /*
                case 3:
                    button_Text.text = "Mutation 4";
                    mutation = Mutation.mutation4;
                    break;
                case 4:
                    button_Text.text = "Mutation 5";
                    mutation = Mutation.mutation5;
                    break;
                */
            }

        }
    }

    public void Mutate()
    {
            switch (mutation)
            {
                case Mutation.mutation1:
                    MutationsManager.Instance.Mutations[0].SetActive(true);
                    break;
                case Mutation.mutation2:
                    MutationsManager.Instance.Mutations[1].SetActive(true);
                    break;
                case Mutation.mutation3:
                    MutationsManager.Instance.Mutations[2].SetActive(true);
                    break;
                case Mutation.mutation4:
                    MutationsManager.Instance.Mutations[3].SetActive(true);
                    break;
                case Mutation.mutation5:
                    MutationsManager.Instance.Mutations[4].SetActive(true);
                    break;
            }
        MutationsManager.Instance.Refresh();
    }
}
