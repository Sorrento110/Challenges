import java.io.File;
import java.io.FileNotFoundException;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.*;

/**
 * Created by Powell on 10/24/2016.
 * Program challenge to find alliteration in sentences and pick them out.
 * RULES OF CHALLENGE:
 * You'll be given an integer on a line, telling you how many lines follow. Then on the subsequent
 * lines, you'll be given a sentence, one per line.
 * Your program should output the words from each sentence that form the group of alliteration.
 * The following are some of the simplest English "stop words", words too common and uninformative to be of much use.
 * In the case of Alliteration, they can come in between the words of interest. (Imported from stopwords file).
 */
public class Main
{

    public static void main(String[] args) throws FileNotFoundException {
        Path stopPath = Paths.get("stopwords.txt");
        File stopWords = new File(stopPath.toString());
        Scanner stopWordsScanner = new Scanner(stopWords);

        Vector<String> stopWordsVec = new Vector<>();
        while(stopWordsScanner.hasNext())
        {
            stopWordsVec.add(stopWordsScanner.nextLine());
        }

        System.out.print("Enter the name of the text input file: ");
        Scanner inputFileName = new Scanner(System.in);
        String inputFile = inputFileName.next();
        inputFileName.close();
        Path inputPath = Paths.get(inputFile);
        File input = new File(inputPath.toString());

        AllitFinder alliteration = new AllitFinder();
        alliteration.findAlliteration(stopWordsVec, input);
    }

}
