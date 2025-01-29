using UnityEngine;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour
{
    public InputField mainInputField;
    public Text validationText;
    public Button continueButton; // Reference to your "Continue" button

    // Start is called before the first frame update
    void Start()
    {
        // Attach the validation function to the input field's onEndEdit event
        mainInputField.onEndEdit.AddListener(ValidateInput);
    }

    // Function to validate input
    void ValidateInput(string userInput)
    {
        // Check if the input is empty
        if (string.IsNullOrEmpty(userInput))
        {
            Debug.LogError("Field is empty! Please input your username letters only).");

            // Show the validation text
            validationText.text = "Field is empty! Please input your username (letters only).";

            // Disable the button
            continueButton.interactable = false;
        }
        // Check if the input contains any non-letter characters
        else if (ContainsNonLetter(userInput))
        {
            Debug.LogError("Invalid input! Input should only contain letters.");

            // Show the validation text
            validationText.text = "Invalid input! Input should only contain letters.";

            // Clear the input field or take other actions as needed
            mainInputField.text = "";

            // Disable the button
            continueButton.interactable = false;
        }
        else
        {
            // Provide a welcome message
            Debug.Log("Welcome, " + userInput + "!");

            // Display a personalized welcome message
            validationText.text = "Welcome, " + userInput + "!";

            // Enable the button
            continueButton.interactable = true;
        }
    }

    // Function to check if a string contains any non-letter characters
    bool ContainsNonLetter(string input)
    {
        foreach (char character in input)
        {
            if (!char.IsLetter(character))
            {
                return true;
            }
        }
        return false;
    }
}
