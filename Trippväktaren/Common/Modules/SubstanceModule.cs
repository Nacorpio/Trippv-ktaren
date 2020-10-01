using System.Threading.Tasks;

using Discord.Commands;

using Sprache;

namespace Trippväktaren.Common.Modules
{
  public class SubstanceModule : ModuleBase<SocketCommandContext>
  {
    [Command("take", true)]
    public async Task Take([Remainder] string input)
    {
      var smp = Parsers.SubstanceMassParser.TryParse(input);

      if (!smp.WasSuccessful)
        return;

      var (substanceName, mass) = smp.Value;

      await Context.Channel.SendMessageAsync($"{Context.User.Mention} tog nyss **{mass.ToString()} {substanceName}**.");
    }
  }

}