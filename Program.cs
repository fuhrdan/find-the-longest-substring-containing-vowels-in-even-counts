//*****************************************************************************
//** 1371. Find the Longest Substring Containing Vowels in Even Counts       **
//*****************************************************************************

int findTheLongestSubstring(char* s) {
    int hashVowel[32];  // To store the first occurrence of each bitmask state
    memset(hashVowel, -1, sizeof(hashVowel));  // Initialize to -1
    hashVowel[0] = 0;  // Base case for even vowels at the start

    int len = strlen(s);
    int longest = 0;
    int state = 0;  // Bitmask to track vowels' parity

    for (int i = 0; i < len; i++) {
        char ch = s[i];

        // Update the state based on the vowel encountered
        if (ch == 'a') {
            state ^= (1 << 0);
        } else if (ch == 'e') {
            state ^= (1 << 1);
        } else if (ch == 'i') {
            state ^= (1 << 2);
        } else if (ch == 'o') {
            state ^= (1 << 3);
        } else if (ch == 'u') {
            state ^= (1 << 4);
        }

        // Check if this state has been seen before
        if (hashVowel[state] != -1) {
            longest = (i + 1) - hashVowel[state] > longest ? (i + 1) - hashVowel[state] : longest;
        } else {
            hashVowel[state] = i + 1;  // Store the first occurrence of this state
        }
    }

    return longest;
}