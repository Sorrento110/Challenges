import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.util.Vector;

/**
 * Created by Powell on 10/24/2016.
 * Class containing all methods to find alliteration in input text.
 */
public class AllitFinder
{
    private Scanner scanner;
    private Vector<String> sentenceVec = new Vector<>();
    private int lines;
    private String temp;
    private String[] sentenceHolder;
    private Vector<String> output = new Vector<>();

    //Constructor
    public AllitFinder()
    {

    }

    //Parent method called in the Main Method.
    public void findAlliteration(Vector<String> stopWords, File input)
    {
        try {
            scanner = new Scanner(input);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        lines = scanner.nextInt();
        for(int i = 0; i <= lines; i++)
        {
            sentenceVec.add(scanner.nextLine());
        }

        for(int i = 0; i < sentenceVec.size(); i++)
        {
            temp = sentenceVec.elementAt(i);
            for(int j = 0; j < stopWords.size(); j++)
            {
                if(temp.contains(stopWords.elementAt(j)))
                {
                    //System.out.print(stopWords.elementAt(j)); <- Debug
                    temp = temp.replaceAll("\\s*\\b"+stopWords.elementAt(j)+"\\b\\s*", " ");
                }
            }
            sentenceHolder = temp.split(" ");
            /*for(String word : sentenceHolder) <- Debug
            {
                System.out.print(word + " ");
            }*/
            analyzeSentence(sentenceHolder);
        }



    }

    //Child method to handle comparing the alliterative parts of each string and printing them to System Output.
    public void analyzeSentence(String[] sentence)
    {
        output.add(" ");
        for(int i = 0; i < sentence.length-1; i++)
        {
            if(sentence[i].substring(0,1).equals(sentence[i+1].substring(0,1)))
            {
                if(!output.lastElement().equals(sentence[i]))
                {
                    output.add(sentence[i]);
                }
                output.add(sentence[i+1]);
            }
        }
        for(String ansPart : output)
        {
            System.out.print(ansPart + " ");
        }
        System.out.println();
        output.removeAllElements();
    }

}
