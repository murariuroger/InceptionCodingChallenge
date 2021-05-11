# InceptionCodingChallenge

"Dreams feel real while we're in them. It's only when we wake up that we realize something was actually strange." - Cobb, Inception (2010) 

The year is 2048. Advanced technologies allow us to introspect our dreams further than ever before. One such device can track our consciousness state while we dream, giving us at the same time the possibility to dream within a dream, greatly warping the perceived time. 

To better understand how this technology works, the model of a timeline in diagram form can give some insights:
![Alt text](https://github.com/murariuroger/InceptionCodingChallenge/blob/master/description-p0.png?raw=true)

A **timeline** consists of a series of time increments, or **ticks**. Each tick is considered atomic in its timeline, meaning that it can not be split into subunits in its timeline. For the purpose of the model it doesn't really matter if a tick is a second, millisecond, nanosecond or any other division of time.

Everything starts from the realtime (or base) timeline, which represents the physical reality. Throughout the timeline, 2 events can happen: the person can start **dreaming (D)** or **wake up (W)**. Whenever a dream starts, a dream timeline is spawned from the base timeline, and ends when the subject wakes up. Events can only occur at the boundary of ticks (T).

And now comes the really interesting part: the person can also enter a dream within a dream, spawning deeper dream timelines, and correspondingly wake from a nested dream into the parent dream. And this is not all, as the true power of the technology stands in the ability to warp time with each nested dream. A setting on the device controls the **time warp factor**, meaning how much faster the time goes by in a timeline relative to its parent timeline. (Still, the person experiences the subjective passing of time exactly the same, so they can not tell the difference between how time flies in a timeline versus another.)

To illustrate in the diagram above, the time warp factor is 2. This means that, while dreaming, each tick in the real timeline corresponds to 2 ticks in the dream timeline. The effect is compound, too, so in the 2nd dream the time is twice as fast as in the 1st one and 4 times as fast as in reality.

A **consciousness stream** is defined as a sequence of ticks and events that the person experiences as a continuous flow, regardless of the timeline they are currently "active" in. For instance, the consciousness stream for the diagram above can be represented as **TDTTDTTTTTWTW** and is colored in red. The stream ends with the last wake up event.

The coding challenge is as follows: given a consciousness stream and a time warp factor, determine:
1. 8 ticks
2. real time - 3 ticks
3. dream 1 - 6 ticks, dream 2 - 5 ticks

Other remarks and constraints (many of these are meant to help reduce the number of edge cases and defensive checks):
- at least 1 tick must occur between a dream and a wake event
- starting dreaming and waking up are considered instantaneous events - they don't consume ticks
- dreams and wake ups can be pass-through, meaning they can "propagate" across timelines without needing ticks - e.g. DDD or WWW
- the input consciousness stream will always fully wake up the person eventually
- due to the atomicity constraint, if a wake event occurs between the start and the end of a tick in the parent timeline, the person will resume from the end of the tick in the parent timeline; this is illustrated in the diagram by the wake event occurring at T5 in Dream 2, returning at end of T5 in Dream 1, even if it occurred in the "middle" of the parent tick
- it is possible for the person to re-enter a dream timeline after waking up, e.g. DTWTDTW
- the consciousness stream will have, at a minimum, 1 tick
- the time warp factor is an integer between 1 and 10
- the brain has its limits, so the number of nested dreams cannot exceed 4

Lastly, here are some other input/output combination examples that the device supports:

Inputs:
Consciousness stream: T (no dreams)
Time warp factor: Any
Outputs:
1. 0
2. 0
3. none

Inputs:
Consciousness stream: DTWTDTTTW
Time warp factor: 3
Outputs:
1. 4
2. 2
3. dream 1 - 4 ticks

Inputs:
Consciousness stream: DDDTTTTTTTTWWW
Time warp factor: 2
Outputs:
1. 8
2. 1
3. dream 1 - 2 ticks, dream 2 - 4 ticks, dream 3 - 8 ticks


