﻿using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIHealthClinic.Repository
{
    public class FeedbackRepository : IFeedback
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

        public void Deletar(Feedback coment)
        {
            Feedback feedbackBuscado = ctx.Feedback.Find(coment)!;
            if (feedbackBuscado != null)
            {
                ctx.Feedback.Remove(feedbackBuscado);
            }
            ctx.SaveChanges();
        }
    }
}
