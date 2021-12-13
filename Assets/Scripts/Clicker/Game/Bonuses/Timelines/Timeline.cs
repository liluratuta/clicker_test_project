using System.Collections;
using System.Collections.Generic;
using Clicker.Game.Bonuses.Timelines.ActionPoints;
using UnityEngine;

namespace Clicker.Game.Bonuses.Timelines
{
    public class Timeline : MonoBehaviour
    {
        private readonly LinkedList<Segment> _segments = new LinkedList<Segment>();

        private float _segmentStartTime;
        private Coroutine _playingCoroutine;

        public void AddActionPoint(IActionPoint actionPoint, float delay)
        {
            var timeAfterSegmentStart = 0f;

            if (_segments.First != null)
            {
                timeAfterSegmentStart = Time.time - _segmentStartTime;
            }
            
            var actionPointDelay = delay + timeAfterSegmentStart;

            var node = _segments.First;
            Segment segment = null;
            float segmentDelay = 0f;
            
            for (; node != null; node = node.Next)
            {
                segment = node.Value;
                segmentDelay += segment.Duration;

                if (segmentDelay > actionPointDelay)
                {
                    break;
                }
            }

            float actionPointDuration = 0f;
            
            if (node == null)
            {
                actionPointDuration = actionPointDelay - segmentDelay;
                _segments.AddLast(new Segment(actionPoint, actionPointDuration));

                if (_segments.Count == 1)
                {
                    StartPlaying();
                }
                
                return;
            }

            var newSegmentDuration = segmentDelay - actionPointDelay;
            actionPointDuration = segment.Duration - newSegmentDuration;

            bool isFirstNode = node == _segments.First;
            
            if (isFirstNode)
            {
                actionPointDuration -= timeAfterSegmentStart;
            }

            _segments.AddBefore(node, new Segment(actionPoint, actionPointDuration));
            _segments.AddBefore(node, new Segment(segment, newSegmentDuration));

            if (isFirstNode)
            {
                RestartPlaying();
            }
        }

        private void RestartPlaying()
        {
            StopCoroutine(_playingCoroutine);
            StartPlaying();
        }

        private void StartPlaying()
        {
            _playingCoroutine = StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
            while (_segments.First != null)
            {
                var first = _segments.First;
                var segment = first.Value;

                _segmentStartTime = Time.time;

                yield return new WaitForSeconds(segment.Duration);
                
                segment.Complete();

                _segments.Remove(first);
            }
        }
    }
}
