using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace APIHealthClinic.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HealthContext ctx;

        public FeedbackRepository()
        {
            ctx = new HealthContext();
        }


        public void Cadastrar(Feedback coment)
        {

            ctx.Feedback.Add(coment);

            ctx.SaveChanges();

        }

        public void Deletar(Guid id)
        {
            Feedback feedbackBuscado = ctx.Feedback.Find(id)!;
            if (feedbackBuscado != null)
            {
                ctx.Feedback.Remove(feedbackBuscado);
            }
            ctx.SaveChanges();
        }
    }
}
