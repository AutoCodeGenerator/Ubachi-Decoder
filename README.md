# Ubachi-Decoder
This is my work to solve the challenge posted on codefights: https://codefights.com/challenge/WbDRnJGc7TYLdtkcp/solutions/fwhp8Szv9bYgCsagY

Description: (take from the codefights page)
During World War I, the Germans used a double columnar transposition cipher called ubchi. To encrypt a certain message with ubchi, one should write it out in rows of a fixed length, and then read out again column by column in specific order. The process should be repeated a second time to ensure safe encryption.

Both the width of the rows and the permutation of the columns are usually defined by a keyword. For example, let the keyword be "pancake" (a word of length 7). The permutation is then defined by the alphabetical order of the letters in the keyword, i.e. 7, 1, 6, 3, 2, 5, 4 (note that that if the keyword has two equal letters, their order is defined by their order in the keyword).

Let the message to be encrypted be "target acquired. Successful extermination". When written out in columns, the following can be obtained:

7163254
target 
acquire
d. Succ
essful 
extermi
nation 

The columns should be rearranged to obtain the following rectangle:

1234567
aeg trt
ciuerqa
.uScc d
suf lse
xreimte
aoi ntn

This rectangle produces the following string: "ac.sxaeiuuroguSfei ec i trclmnrq stttadeen".

The process should be repeated again with the following results:

7163254        1234567
ac.sxae        cxsea.a
iuurogu        uorugui
Sfei ec  --->  f iceeS
 i trcl        irtlc  
mnrq st        n qtsrm
ttadeen        tedneat

The resulting encrypted string is thus "cufintxo r esritqdeucltnagecse.ue raaiS mt".

Given encrypted message and the keyword, your task is to decrypt it and return the original message.

Example

For message = "cufintxo r esritqdeucltnagecse.ue raaiS mt"
and keyword = "pancake", the output should be
Ubachi(message, keyword) = "target acquired. Successful extermination ".

This example corresponds to the example given in the description above. Note, that it has a whitespace character at the end: that is because the encryption requires a message that can be written out in a rectangle.

Input/Output

    [time limit] 3000ms (cs)

    [input] string message

    A message encrypted with ubachi encryption.

    Constraints:
    keyword.length ≤ message.length ≤ 120.

    [input] string keyword

    A keyword representing ubachi transposition key. It is guaranteed to contain only lowercase English letters.

    Constraints:
    3 ≤ keyword.length ≤ message.length.

    [output] string

    Decoded message.

