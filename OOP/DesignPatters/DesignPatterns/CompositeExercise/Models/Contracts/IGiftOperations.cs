﻿namespace CompositeExercise.Models.Contracts;
public interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}
