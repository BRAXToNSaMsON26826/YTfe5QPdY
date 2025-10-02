// 代码生成时间: 2025-10-02 18:09:34
using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

/// <summary>
/// SpeechRecognitionSystem is a class that handles voice recognition functionality.
/// </summary>
public class SpeechRecognitionSystem : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private string[] keywords;
    private float confidenceLevel;
    private bool isListening = false;

    /// <summary>
    /// Initializes the speech recognition system with a list of keywords and a confidence level.
    /// </summary>
    /// <param name="keywordsToRecognize">List of keywords to recognize.</param>
    /// <param name="confidenceLevelToRecognize">Confidence level for recognizing keywords.</param>
    public void Initialize(string[] keywordsToRecognize, float confidenceLevelToRecognize)
    {
        keywords = keywordsToRecognize;
        confidenceLevel = confidenceLevelToRecognize;
        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        isListening = true;
    }

    /// <summary>
    /// Starts the speech recognition system to listen for keywords.
    /// </summary>
    public void StartListening()
    {
        if (!isListening)
        {
            keywordRecognizer.Start();
            isListening = true;
        }
    }

    /// <summary>
    /// Stops the speech recognition system from listening for keywords.
    /// </summary>
    public void StopListening()
    {
        if (isListening)
        {
            keywordRecognizer.Stop();
            isListening = false;
        }
    }

    /// <summary>
    /// Event handler for when a keyword is recognized.
    /// </summary>
    /// <param name="args">PhraseRecognizedEventArgs containing the recognized keyword and confidence level.</param>
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.confidence >= confidenceLevel)
        {
            Debug.Log($"Keyword recognized: {args.text} with confidence: {args.confidence}");
            // TODO: Add additional actions based on the recognized keyword.
        }
        else
        {
            Debug.LogWarning($"Keyword recognized {args.text} with low confidence: {args.confidence}. Ignoring.");
        }
    }

    /// <summary>
    /// Ensures that the speech recognition system is properly disposed of when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        if (keywordRecognizer != null)
        {
            keywordRecognizer.Dispose();
        }
    }
}
