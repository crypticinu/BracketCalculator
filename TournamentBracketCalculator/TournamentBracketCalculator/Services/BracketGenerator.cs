using System.Collections.Generic;
using System.Linq;
using TournamentBracketCalculator.Models;

namespace TournamentBracketCalculator.Services
{
    public static class BracketGenerator
    {

        public static Dictionary<Category, List<Group>> GenerateBrackets(List<Player> competeingPlayers)
        {
            var groups = new Dictionary<Category, List<Group>>();

            var goldPlayers = competeingPlayers.Where(x => x.Category == Category.Gold).ToList();
            var silverPlayers = competeingPlayers.Where(x => x.Category == Category.Silver).ToList();
            var bronzeAPlayers = competeingPlayers.Where(x => x.Category == Category.Bronze_A).ToList();
            var bronzeBPlayers = competeingPlayers.Where(x => x.Category == Category.Bronze_B).ToList();

            groups.Add(Category.Gold, GenerateGroups(Category.Gold, goldPlayers));
            groups.Add(Category.Silver, GenerateGroups(Category.Silver, silverPlayers));
            groups.Add(Category.Bronze_A, GenerateGroups(Category.Bronze_A, bronzeAPlayers));
            groups.Add(Category.Bronze_B, GenerateGroups(Category.Bronze_B, bronzeBPlayers));

            return groups;
        }

        private static List<Group> GenerateGroups(Category category, List<Player> categorizedPlayers)
        {
            var groupSizes = GenerateGroupSizes(categorizedPlayers.Count());

            var result = new Group[groupSizes.Count];

            for (int i = 0; i < groupSizes.Count; i++)
            {
                result[i] = new Group
                {
                    Category = category,
                    Size = groupSizes[i]
                };
            }
            var rankedPlayers = categorizedPlayers.OrderBy(x => x.Points).ToList();

            var currentGroup = 0;

            foreach (var currentPlayer in categorizedPlayers)
            {
                result[currentGroup].Players.Add(currentPlayer);
                currentGroup++;

                if (currentGroup == groupSizes.Count)
                {
                    currentGroup = 0;
                }
            }

            return result.ToList();
        }
        private static List<int> GenerateGroupSizes(int numberOfPlayers)
        {
            if (numberOfPlayers < 8 || numberOfPlayers > 20)
            {
                throw new System.Exception($"Unsupported number of players for group: {numberOfPlayers}");
            }

            var groupings = new List<int>();

            if (numberOfPlayers == 10 || numberOfPlayers == 20) //all groups of 5
            {
                for (int i = 0; i < numberOfPlayers / 5; i++)
                {
                    groupings.Add(5);
                }
            }
            else if (numberOfPlayers == 11)
            {
                groupings.Add(6);
                groupings.Add(5);
            }
            else if (numberOfPlayers % 4 == 0) //all groups of 4
            {
                for (int i = 0; i < numberOfPlayers / 4; i++)
                {
                    groupings.Add(4);
                }
            }
            else  //mixture of 5 and 4 groups
            {
                while (numberOfPlayers != 0)
                {
                    if (numberOfPlayers % 4 == 0)
                    {
                        for (int i = 0; i < numberOfPlayers / 4; i++)
                        {
                            groupings.Add(4);
                            numberOfPlayers -= 4;
                        }
                    }
                    else
                    {
                        numberOfPlayers -= 5;
                        groupings.Add(5);
                    }
                }
            }
            return groupings;
        }
    }
}
