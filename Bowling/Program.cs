// See https://aka.ms/new-console-template for more information

List<int> scores = new List<int> { 10, 3, 6, 5, 5, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 3, 6};
List<int> scores2 = new List<int> { 10, 10, 5, 5, 9, 0, 3, 7, 4, 6, 10, 8, 2, 8, 1, 6, 4, 7 };
//Perfect game
List<int> scores3 = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
CalculateScore(scores);
CalculateScore(scores2);
CalculateScore(scores3);
static void CalculateScore(List<int> scores)
{
    var finalscore = 0;
    var frameCount = 0;
    for (int i = 0; i < scores.Count; i++)
    {
        //handle 10th frame logic
        if (frameCount == 10)
        {
            break;
        }

        //Strike
        if (scores[i] == 10 && frameCount < 10)
        {
            //10pts for strike + score for next two balls
            finalscore += 10 + (scores[i + 1] + scores[i + 2]);
            //track current frame
            frameCount++;
            Console.WriteLine($"Frame: {frameCount}, score: {finalscore}, iterator: {i}");
            continue;
        }
        //Spare
        else if ((scores[i] + scores[i+1]) == 10)
        {
            //Bonus points spare, ball1 + ball2 + bonus ball
            finalscore += scores[i] + scores[i+1] + scores[i+2];
            //as we have accounted for the next two balls, add one to iterator and continue to skip the next ball 
            i++;
            frameCount++;
            Console.WriteLine($"Frame: {frameCount}, score: {finalscore}, iterator: {i}");
            continue;
        }
        //no bonus points
        else
        {
            finalscore += scores[i] + scores[i + 1];
            frameCount++;
            i++;
            Console.WriteLine($"Frame: {frameCount}, score: {finalscore}, iterator: {i}");
            continue;
        }
    }
    Console.WriteLine($"Final Score: {finalscore}");
}